using FlightRadar.Client.Models.V1;

namespace FlightRadar.Tests.FilterTests.V1;

public class FlightSummaryFilterTests
{
    [Fact]
    public void ToString_ReturnsCorrectString_WhenPropertiesArePopulated()
    {
        // Arrange
        var filter = new FlightSummaryFilter
        {
            From = new DateTime(2022, 1, 1),
            To = new DateTime(2022, 12, 31),
            Flights = ["AB123", "XY456"],
            Callsigns = ["CALL123", "CALL456"],
            Registrations = ["REG123"],
            PaintedAs = ["PAINT1"],
            OperatingAs = ["OPER1"],
            Routes = ["ROUTE1", "ROUTE2"],
            Aircraft = ["A320", "B737"],
            SortingOrder = SortingOrder.Descending,
            Limit = 100
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "flight_datetime_from=2022-01-01T00:00:00Z&flight_datetime_to=2022-12-31T00:00:00Z&flights=AB123,XY456&callsigns=CALL123,CALL456&registrations=REG123&painted_as=PAINT1&operating_as=OPER1&routes=ROUTE1,ROUTE2&aircraft=A320,B737&sort=desc&limit=100";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ReturnsEmptyString_WhenNoPropertiesArePopulated()
    {
        // Arrange
        var filter = new FlightSummaryFilter(); // Empty filter, no properties set

        // Act
        var result = filter.ToString();

        // Assert
        Assert.Equal("", result); // Should return an empty string since no properties are populated
    }

    [Fact]
    public void ToString_ReturnsCorrectString_WhenSomePropertiesArePopulated()
    {
        // Arrange
        var filter = new FlightSummaryFilter
        {
            FlightIds = ["FLIGHT1", "FLIGHT2"],
            Flights = ["AB123"],
            SortingOrder = SortingOrder.Ascending
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "flight_ids=FLIGHT1,FLIGHT2&flights=AB123";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ReturnsCorrectString_WithDateRange()
    {
        // Arrange
        var filter = new FlightSummaryFilter
        {
            From = new DateTime(2022, 1, 1),
            To = new DateTime(2022, 12, 31)
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "flight_datetime_from=2022-01-01T00:00:00Z&flight_datetime_to=2022-12-31T00:00:00Z";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_DoesNotIncludeEmptyListsOrNullValues()
    {
        // Arrange
        var filter = new FlightSummaryFilter
        {
            FlightIds = ["FLIGHT1"],
            Flights = [],
            Callsigns = [],
            Registrations = [],
            PaintedAs = [],
            OperatingAs = [],
            Routes = [],
            Aircraft = [],
            Limit = null
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "flight_ids=FLIGHT1";
        Assert.Equal(expected, result); // Should only include flight_ids=FLIGHT1
    }

    [Fact]
    public void ToString_HandlesMaxValuesForLists()
    {
        // Arrange
        var filter = new FlightSummaryFilter
        {
            Flights = Enumerable.Range(1, 15).Select(i => $"FLIGHT{i}").ToList()
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "flights=FLIGHT1,FLIGHT2,FLIGHT3,FLIGHT4,FLIGHT5,FLIGHT6,FLIGHT7,FLIGHT8,FLIGHT9,FLIGHT10,FLIGHT11,FLIGHT12,FLIGHT13,FLIGHT14,FLIGHT15";
        Assert.Equal(expected, result); // Should handle up to 15 elements
    }

    [Fact]
    public void ToString_ReturnsCorrectString_WithLimit()
    {
        // Arrange
        var filter = new FlightSummaryFilter
        {
            Limit = 500
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expected = "limit=500";
        Assert.Equal(expected, result); // Should include limit=500
    }
}