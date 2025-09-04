# 📦 ManifestRegistryResolverFactory

## 🧭 Purpose

This factory interprets contributor phase and returns a narratable `IManifestRegistryResolver`. Each resolver hydrates manifests using the `IntentEnvelope`, applying emotional context when supported via `IEmotionallyReactiveManifest`.

It ensures that contributors receive phase-specific registry behavior without needing to understand internal orchestration logic.

---

## 🧩 How It Works

- Accepts a `phase` string (e.g. `"curation"`, `"assembly"`, `"onboarding"`).
- Normalizes the phase and looks up a resolver from `_resolverMap`.
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
To register a new phase resolver:
- Implement IManifestRegistryResolver for your phase.
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
- Modular: New phases can be added safely.
- Emotionally reactive: Traits and tone are preserved when supported.
If you're unsure how your resolver will be experienced by contributors, ask:
“How will this manifest feel when it’s hydrated? Is it narratable, safe, and emotionally clear?”


---

Let me know if you'd like a companion doc for contributors who want to build new `PayloadPackage`s or extend the emotional mesh. We can call it `PayloadDesignGuide.md` and make it tone-aware and designer-friendly.


