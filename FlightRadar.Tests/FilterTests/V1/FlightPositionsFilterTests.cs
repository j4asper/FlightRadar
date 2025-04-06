using FlightRadar.Core.Models.V1.Filters;
using FlightRadar.Entities.Models.V1;

namespace FlightRadar.Tests.FilterTests.V1;

public class FlightPositionsFilterTests
{
    [Fact]
    public void ToString_ReturnsCorrectString_WhenPropertiesArePopulated()
    {
        // Arrange
        var filter = new FlightPositionsFilter
        {
            Bounds = new BoundingBox(10.123, 20.456, 30.789, 40.012),
            Flights = ["AB123", "XY456"],
            Callsigns = ["CALL123", "CALL456"],
            Registrations = ["REG123"],
            PaintedAs = ["PAINT1"],
            OperatingAs = ["OPER1"],
            Routes = ["ROUTE1", "ROUTE2"],
            Aircraft = ["A320", "B737"],
            AltitudeRanges = [new AltitudeRange { LowerLimit = 0, UpperLimit = 10000 }],
            Squawks = ["1234", "5678"],
            Categories = [FlightCategory.Cargo],
            DataSources = [DataSource.ADSB],
            Airspaces = ["Airspace1"],
            GroundSpeed = "120-140",
            Limit = 500
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "bounds=10.123,20.456,30.789,40.012&flights=AB123,XY456&callsigns=CALL123,CALL456&registrations=REG123&painted_as=PAINT1&operating_as=OPER1&routes=ROUTE1,ROUTE2&aircraft=A320,B737&altitude_ranges=0-10000&squawks=1234,5678&categories=C&data_sources=ADSB&airspaces=Airspace1&gspeed=120-140&limit=500";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ReturnsEmptyString_WhenNoPropertiesArePopulated()
    {
        // Arrange
        var filter = new FlightPositionsFilter(); // Empty filter, no properties set

        // Act
        var result = filter.ToString();

        // Assert
        Assert.Equal("", result); // Should return an empty string since no properties are populated
    }

    [Fact]
    public void ToString_ReturnsCorrectString_WhenSomePropertiesArePopulated()
    {
        // Arrange
        var filter = new FlightPositionsFilter
        {
            Flights = ["AB123", "XY456"],
            Callsigns = ["CALL123"],
            GroundSpeed = "120-140"
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "flights=AB123,XY456&callsigns=CALL123&gspeed=120-140";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_DoesNotIncludeEmptyListsOrNullValues()
    {
        // Arrange
        var filter = new FlightPositionsFilter
        {
            Flights = ["AB123"],
            Callsigns = [],
            Registrations = [],
            GroundSpeed = null,
            Limit = null
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "flights=AB123";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ReturnsCorrectString_WithSingleValueInList()
    {
        // Arrange
        var filter = new FlightPositionsFilter
        {
            Flights = ["AB123"],
            Squawks = ["1234"]
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "flights=AB123&squawks=1234";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_HandlesMaxValuesForLists()
    {
        // Arrange
        var filter = new FlightPositionsFilter
        {
            Flights = ["FLIGHT1", "FLIGHT2", "FLIGHT3", "FLIGHT4", "FLIGHT5", "FLIGHT6", "FLIGHT7", "FLIGHT8", "FLIGHT9", "FLIGHT10", "FLIGHT11", "FLIGHT12", "FLIGHT13", "FLIGHT14", "FLIGHT15"]
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "flights=FLIGHT1,FLIGHT2,FLIGHT3,FLIGHT4,FLIGHT5,FLIGHT6,FLIGHT7,FLIGHT8,FLIGHT9,FLIGHT10,FLIGHT11,FLIGHT12,FLIGHT13,FLIGHT14,FLIGHT15";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ReturnsCorrectString_WithBounds()
    {
        // Arrange
        var filter = new FlightPositionsFilter
        {
            Bounds = new BoundingBox(10.123, 20.456, 30.789, 40.012)
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "bounds=10.123,20.456,30.789,40.012";
        Assert.Equal(expected, result);
    }
}