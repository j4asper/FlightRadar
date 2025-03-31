using System.ComponentModel;

namespace FlightRadar.Entities.Models.V1;

/// <summary>
/// Enum representing different flight categories, each with a human-readable name and an associated string value.
/// </summary>
public enum FlightCategory
{
    /// <summary>
    /// Commercial aircraft that carry passengers as their primary purpose.
    /// </summary>
    [Description("P")]
    Passenger,

    /// <summary>
    /// Aircraft that carry only cargo.
    /// </summary>
    [Description("C")]
    Cargo,

    /// <summary>
    /// Aircraft operated by military or a governmental agency.
    /// </summary>
    [Description("M")]
    MilitaryAndGovernment,

    /// <summary>
    /// Larger private aircraft, such as Gulfstream, Bombardier, and Pilatus.
    /// </summary>
    [Description("J")]
    BusinessJets,

    /// <summary>
    /// Non-commercial transport flights, including private, ambulance, aerial survey, flight training, and instrument calibration aircraft.
    /// </summary>
    [Description("T")]
    GeneralAviation,

    /// <summary>
    /// Rotary wing aircraft.
    /// </summary>
    [Description("H")]
    Helicopters,

    /// <summary>
    /// Lighter-than-air aircraft, including gas-filled airships of all kinds.
    /// </summary>
    [Description("B")]
    LighterThanAir,

    /// <summary>
    /// Unpowered aircraft.
    /// </summary>
    [Description("G")]
    Gliders,

    /// <summary>
    /// Uncrewed aircraft, ranging from small consumer drones to larger UAVs.
    /// </summary>
    [Description("D")]
    Drones,

    /// <summary>
    /// Transponder-equipped vehicles, such as push-back tugs, fire trucks, and operations vehicles.
    /// </summary>
    [Description("V")]
    GroundVehicles,

    /// <summary>
    /// Aircraft appearing on Flightradar24 not classified elsewhere, such as the International Space Station, UFOs, Santa, etc.
    /// </summary>
    [Description("O")]
    Other,

    /// <summary>
    /// Aircraft not yet placed into a category in the Flightradar24 database.
    /// </summary>
    [Description("N")]
    NonCategorized
}