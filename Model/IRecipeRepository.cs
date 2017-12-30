using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetAllNotes();
    Task<Recipe> GetNote(string id);
    Task AddNote(Recipe item);
    Task<bool> RemoveNote(string id);
    Task<bool> UpdateNote(string id, string body);
    Task<bool> UpdateNoteDocument(string id, string body);
    Task<bool> RemoveAllNotes();
}