using FlightRadar.Core.Models.V1.Filters;

namespace FlightRadar.Tests.FilterTests.V1;

public class HistoricFlightPositionFilterTests
{
    [Fact]
    public void ToString_ReturnsCorrectString_WithTimestamp()
    {
        // Arrange
        var filter = new HistoricFlightPositionFilter
        {
            Timestamp = new DateTime(2023, 4, 5, 14, 30, 0, DateTimeKind.Utc),
            Bounds = new BoundingBox(10.123, 20.456, 30.789, 40.012),
            Flights = ["AB123"],
            Callsigns = ["CALL123"],
            Limit = 100
        };

        // Act
        var result = filter.ToString();

        // Assert
        var unixTimestamp = ((DateTimeOffset)filter.Timestamp).ToUnixTimeSeconds();
        var expected = $"bounds=10.123,20.456,30.789,40.012&flights=AB123&callsigns=CALL123&limit=100&timestamp={unixTimestamp}";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_IncludesCorrectUnixTimestamp()
    {
        // Arrange
        var filter = new HistoricFlightPositionFilter
        {
            Timestamp = new DateTime(2022, 1, 1, 12, 0, 0, DateTimeKind.Utc)
        };

        // Act
        var result = filter.ToString();

        // Assert
        var expectedUnixTimestamp = ((DateTimeOffset)filter.Timestamp).ToUnixTimeSeconds();
        Assert.Contains($"timestamp={expectedUnixTimestamp}", result);
    }

    [Fact]
    public void ToString_HandlesEdgeCases_WithTimestamp()
    {
        // Arrange
        var filter = new HistoricFlightPositionFilter
        {
            Timestamp = new DateTime(2016, 5, 12, 0, 0, 0, DateTimeKind.Utc)
        };

        // Act
        var result = filter.ToString();

        // Assert
        var unixTimestamp = ((DateTimeOffset)filter.Timestamp).ToUnixTimeSeconds();
        Assert.Contains($"timestamp={unixTimestamp}", result);
    }

    [Fact]
    public void ToString_ReturnsCorrectString_WhenNoOtherPropertiesSet()
    {
        // Arrange
        var filter = new HistoricFlightPositionFilter
        {
            Timestamp = new DateTime(2023, 4, 5, 14, 30, 0, DateTimeKind.Utc)
        };

        // Act
        var result = filter.ToString();

        // Assert
        var unixTimestamp = ((DateTimeOffset)filter.Timestamp).ToUnixTimeSeconds();
        var expected = $"timestamp={unixTimestamp}";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ReturnsEmptyString_WhenNoPropertiesSetExceptTimestamp()
    {
        // Arrange
        var filter = new HistoricFlightPositionFilter
        {
            Timestamp = new DateTime(2023, 4, 5, 14, 30, 0, DateTimeKind.Utc)
        };

        // Act
        var result = filter.ToString();

        // Assert
        Assert.Contains("timestamp", result); // Ensures the timestamp is included even when other properties are not set
    }
}