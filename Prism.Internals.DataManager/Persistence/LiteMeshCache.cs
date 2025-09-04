using LiteDB;
using Prism.Shared.Contracts;
using Prism.Shared.Contracts.Events;

namespace Prism.Internals.DataManager.Persistence;

public class LiteMeshCache
{
    private readonly LiteDatabase _db;

    public LiteMeshCache(string dbPath = "PrismMeshCache.db")
    {
        _db = new LiteDatabase(dbPath);
    }

    public void SaveProfiles(List<MeshProfile> profiles)
    {
        var col = _db.GetCollection<MeshProfile>("Contributors");
        col.Upsert(profiles);
    }

    public List<MeshProfile> LoadProfiles()
    {
        var col = _db.GetCollection<MeshProfile>("Contributors");
        return col.FindAll().ToList();
    }

    public void SaveRipple(RippleEvent ripple)
    {
        var col = _db.GetCollection<RippleEvent>("RippleEvents");
        col.Insert(ripple);
    }
}