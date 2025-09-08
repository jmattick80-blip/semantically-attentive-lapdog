# Prism.Unity.Bridge

🎮 **Purpose**  
Prism.Unity.Bridge connects Prism OS’s simulation contracts to Unity’s runtime environment. It serves as the Unity-facing half of the adapter system, translating emotionally scoped data, trait bundles, and session artifacts into Unity-compatible behaviors, overlays, and emitters.

---

## 🧠 Architectural Role

- Bridges Prism.Shared.Contracts to Unity MonoBehaviours and runtime components
- Enables Unity scenes to hydrate NPCs, traits, and emotional mesh data
- Supports prefab-safe simulation scaffolds and contributor-safe overlays
- Provides Unity-compatible entry points for session orchestration and trait modulation

---

## 🔗 Adapter Relationship

This project complements the **Prism.Adapter** layer, which handles upstream translation from Unity to Prism.  
Together, they form a bidirectional bridge:

| Direction | Role |
|-----------|------|
| `Prism.Adapter` → Prism | Unity → Prism intent, fingerprint, and envelope translation |
| `Prism.Unity.Bridge` → Unity | Prism → Unity trait bundles, NPC hydration, and emotional consequence |

---

## 🧩 Key Responsibilities

- Hydrate Unity NPCs from `NpcDefinition` and `TraitTriggerMap`
- Surface `ToneResponseManifest` feedback in Unity UI or voice layers
- Translate `SessionContext` into Unity scene state
- Support Unity-side replay scaffolding and emotional consequence narration

---

## 🛠️ Unity Integration Notes

- Targets `.NETStandard 2.0` for Unity compatibility
- Avoids direct dependencies on UnityEditor or platform-specific APIs
- Designed for runtime injection via Unity DI containers or MonoBehaviour proxies
- Emotionally scoped feedback should be surfaced via Unity UI, voice synthesis, or animation triggers

---

## 🧾 Audit Summary

This project is scoped, stable, and ready for Unity-side integration.  
All adapter responsibilities are narratable and prefab-safe.  
Ready for contributor onboarding, simulation replay, and emotional