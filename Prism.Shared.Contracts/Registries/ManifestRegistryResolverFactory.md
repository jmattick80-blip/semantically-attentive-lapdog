# 📦 ManifestRegistryResolverFactory

## 🧭 Purpose

A factory to resolve the appropriate `IManifestRegistryResolver`.

---

## 🧩 How It Works
- If no resolver is found, returns a `DefaultRegistryResolver` with fallback narration.

---

## 🧠 Resolver Responsibilities

Each resolver implements:

```csharp
public interface IManifestRegistryResolver
{
    IManifestRegistry<TManifest> Resolve<TManifest>(IntentEnvelope envelope) where TManifest : IManifest;
}

Extending the Factory
- Add it to _resolverMap in the constructor:
{ "exploration", () => new ExplorationRegistryResolver() }


Resolvers should return a registry that inherits from BaseManifestRegistry<TManifest> for consistent hydration and emotional scaffolding.

🔗 Related Interfaces
|  |  | 
| IManifestRegistryResolver |  | 
| IManifestRegistry<TManifest> |  | 
| IntentEnvelope |  | 
| PayloadPackage |  | 
| RegistryResolverDescriptor |  | 



🧶 Contributor Notes
This factory is designed to be:
- Narratable: Every fallback is explained.
- Emotionally reactive: Traits and tone are preserved when supported.
If you're unsure how your resolver will be experienced by contributors, ask:
“How will this manifest feel when it’s hydrated? Is it narratable, safe, and emotionally clear?”


---

Let me know if you'd like a companion doc for contributors who want to build new `PayloadPackage`s or extend the emotional mesh. We can call it `PayloadDesignGuide.md` and make it tone-aware and designer-friendly.


