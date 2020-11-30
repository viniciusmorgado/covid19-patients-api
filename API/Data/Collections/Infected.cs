using System;
using MongoDB.Driver.GeoJsonObjectModel;

public class Infected
{
    public Infected(DateTime birthday, string sex, double longitude, double latitude)
    {
        this.Birthday = birthday;
        this.Sex = sex;
        this.Location = new GeoJson2DGeographicCoordinates(longitude, latitude);
    }

    public DateTime Birthday { get; set; }
    public string Sex { get; set; }
    public GeoJson2DGeographicCoordinates Location { get; set; }
}