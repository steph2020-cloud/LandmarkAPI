using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace LandmarksAPI.Models
{

    public partial class Venue
    {
        //database key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VenuesID { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        public List<Category> Categories { get; set; }

        [JsonProperty("verified", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Verified { get; set; }

    }
    public partial class Category
    {
        //category databse key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CatetoryID { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("pluralName", NullValueHandling = NullValueHandling.Ignore)]
        public string PluralName { get; set; }

        [JsonProperty("shortName", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortName { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public Icon Icon { get; set; }

        [JsonProperty("primary", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Primary { get; set; }
    }

    public partial class Icon
    {
        //Icon database  key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "varchar(200)")]
        [JsonProperty("prefix", NullValueHandling = NullValueHandling.Ignore)]

        public string Prefix { get; set; }

        [JsonProperty("suffix", NullValueHandling = NullValueHandling.Ignore)]
        public string Suffix { get; set; }
        [JsonProperty("ImageBytes", NullValueHandling = NullValueHandling.Ignore)]
        public byte[] ImageBytes { get; set; }
    }

    public partial class Location
    {
        //Location database key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationKey { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public string? Lat { get; set; }

        [JsonProperty("lng", NullValueHandling = NullValueHandling.Ignore)]
        public string? Lng { get; set; }

        [JsonProperty("distance", NullValueHandling = NullValueHandling.Ignore)]
        public long? Distance { get; set; }

        [JsonProperty("postalCode", NullValueHandling = NullValueHandling.Ignore)]
        public long? PostalCode { get; set; }

        [JsonProperty("cc", NullValueHandling = NullValueHandling.Ignore)]
        public string Cc { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

    }


    #region removed commented out some classes may might be needed by other APIs

    //supported primitive type or a valid entity 
    //[JsonProperty("formattedAddress", NullValueHandling = NullValueHandling.Ignore)]
    // public List<string> FormattedAddress { get; set; }
    //public partial class Photos
    //{
    //    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? Count { get; set; }

    //    [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
    //    public List<object> Groups { get; set; }
    //}

    //[JsonProperty("labeledLatLngs", NullValueHandling = NullValueHandling.Ignore)]
    //public List<LabeledLatLng> LabeledLatLngs { get; set; }
    //public partial class LabeledLatLng
    //{
    //    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Label { get; set; }

    //    [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? Lat { get; set; }

    //    [JsonProperty("lng", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? Lng { get; set; }
    //}
    //public partial class Stats
    //{
    //    [JsonProperty("tipCount", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? TipCount { get; set; }

    //    [JsonProperty("usersCount", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? UsersCount { get; set; }

    //    [JsonProperty("checkinsCount", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? CheckinsCount { get; set; }

    //    [JsonProperty("visitsCount", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? VisitsCount { get; set; }
    //}

    //public partial class SuggestedBounds
    //{
    //    [JsonProperty("ne", NullValueHandling = NullValueHandling.Ignore)]
    //    public Ne Ne { get; set; }

    //    [JsonProperty("sw", NullValueHandling = NullValueHandling.Ignore)]
    //    public Ne Sw { get; set; }
    //}

    //public partial class Ne
    //{
    //    [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? Lat { get; set; }

    //    [JsonProperty("lng", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? Lng { get; set; }
    //}

    //public partial class SuggestedFilters
    //{
    //    [JsonProperty("header", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Header { get; set; }

    //    [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
    //    public List<Filter> Filters { get; set; }
    //}

    //public partial class Filter
    //{
    //    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Name { get; set; }

    //    [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Key { get; set; }
    //}

    //public partial class Warning
    //{
    //    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Text { get; set; }
    //}

    //public partial class Landmarks
    //{
    //    [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
    //    public Meta Meta { get; set; }

    //    [JsonProperty("response", NullValueHandling = NullValueHandling.Ignore)]
    //    public Response Response { get; set; }
    //}

    //public partial class Meta
    //{
    //    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? Code { get; set; }

    //    [JsonProperty("requestId", NullValueHandling = NullValueHandling.Ignore)]
    //    public string RequestId { get; set; }
    //}

    //public partial class Response
    //{
    //    [JsonProperty("suggestedFilters", NullValueHandling = NullValueHandling.Ignore)]
    //    public SuggestedFilters SuggestedFilters { get; set; }

    //    [JsonProperty("warning", NullValueHandling = NullValueHandling.Ignore)]
    //    public Warning Warning { get; set; }

    //    [JsonProperty("suggestedRadius", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? SuggestedRadius { get; set; }

    //    [JsonProperty("headerLocation", NullValueHandling = NullValueHandling.Ignore)]
    //    public string HeaderLocation { get; set; }

    //    [JsonProperty("headerFullLocation", NullValueHandling = NullValueHandling.Ignore)]
    //    public string HeaderFullLocation { get; set; }

    //    [JsonProperty("headerLocationGranularity", NullValueHandling = NullValueHandling.Ignore)]
    //    public string HeaderLocationGranularity { get; set; }

    //    [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Query { get; set; }

    //    [JsonProperty("totalResults", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? TotalResults { get; set; }

    //    [JsonProperty("suggestedBounds", NullValueHandling = NullValueHandling.Ignore)]
    //    public SuggestedBounds SuggestedBounds { get; set; }

    //    [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
    //    public List<Group> Groups { get; set; }
    //}

    //public partial class Group
    //{
    //    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Type { get; set; }

    //    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Name { get; set; }

    //    [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
    //    public List<GroupItem> Items { get; set; }
    //}

    //public partial class GroupItem
    //{
    //    [JsonProperty("reasons", NullValueHandling = NullValueHandling.Ignore)]
    //    public Reasons Reasons { get; set; }

    //    [JsonProperty("venue", NullValueHandling = NullValueHandling.Ignore)]
    //    public Venue Venue { get; set; }

    //    [JsonProperty("flags", NullValueHandling = NullValueHandling.Ignore)]
    //    public Flags Flags { get; set; }

    //    [JsonProperty("referralId", NullValueHandling = NullValueHandling.Ignore)]
    //    public string ReferralId { get; set; }
    //}

    //public partial class Flags
    //{
    //    [JsonProperty("outsideRadius", NullValueHandling = NullValueHandling.Ignore)]
    //    public bool? OutsideRadius { get; set; }
    //}

    //public partial class Reasons
    //{
    //    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? Count { get; set; }

    //    [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
    //    public List<ReasonsItem> Items { get; set; }
    //}

    //public partial class ReasonsItem
    //{
    //    [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Summary { get; set; }

    //    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Type { get; set; }

    //    [JsonProperty("reasonName", NullValueHandling = NullValueHandling.Ignore)]
    //    public string ReasonName { get; set; }
    //}
    //[JsonProperty("stats", NullValueHandling = NullValueHandling.Ignore)]
    //public Stats Stats { get; set; }

    //[JsonProperty("beenHere", NullValueHandling = NullValueHandling.Ignore)]
    //public BeenHere BeenHere { get; set; }

    //[JsonProperty("photos", NullValueHandling = NullValueHandling.Ignore)]
    //public Photos Photos { get; set; }

    //[JsonProperty("hereNow", NullValueHandling = NullValueHandling.Ignore)]
    //public HereNow HereNow { get; set; }


    //public partial class BeenHere
    //{
    //    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? Count { get; set; }

    //    [JsonProperty("lastCheckinExpiredAt", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? LastCheckinExpiredAt { get; set; }

    //    [JsonProperty("marked", NullValueHandling = NullValueHandling.Ignore)]
    //    public bool? Marked { get; set; }

    //    [JsonProperty("unconfirmedCount", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? UnconfirmedCount { get; set; }
    //}
    //public partial class Contact
    //{
    //}

    //public partial class HereNow
    //{
    //    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? Count { get; set; }

    //    [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
    //    public string Summary { get; set; }

    //    [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
    //    public List<object> Groups { get; set; }
    //}


    #endregion

}