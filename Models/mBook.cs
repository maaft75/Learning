using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace bookApi.Models;

public class mBook
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [Required]
    public string Name{get; set;}
    [Required]
    public string AuthorName{get; set;}
    [Required]
    public DateTime DateCreated{get; set;}
    [Required]
    public DateTime DateUpdated{get; set;}
}