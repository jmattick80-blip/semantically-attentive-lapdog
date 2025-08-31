# Prism Shared Agents

This folder defines prefab-safe agent structures used to feed Prism’s simulation runtime with trait-trigger mappings, emotional consequence hooks, and contributor-defined metadata. These agents are external-facing and designed to be hydrated by systems outside Prism—such as Unity prefab importers, scenario loaders, or contributor archetype builders.

## Purpose

Agents are the bridge between contributor-authored content and Prism’s transformation engine. They define traits, overlays, and emotional triggers that Prism uses to route consequence, mood shifts, and scenario logic.

## Included Types

### `NpcDefinition.cs`
Defines a non-player character (NPC) with:
- `NpcId`: Unique identifier
- `DisplayName`: Contributor-facing name
- `TraitTriggerMap`: A list of trait-trigger pairs used to drive scenario consequence

### `TraitTriggerMap.cs`
Contains a list of `TraitTrigger` entries:
- `TraitName`: Semantic tag (e.g. "Haunted", "Reactive")
- `TriggerKey`: Consequence domain (e.g. "Overlay", "AccessRestriction")
- `TriggerValue`: Specific reaction or mutation (e.g. "Distortion", "CuratorGate")

## Usage

These definitions are typically hydrated during Prism boot via:

```csharp
var npcDefinitions = ExternalNpcLoader.GetAll();
var traitMap = TraitTriggerImporter.BuildFromNpcDefinitions(npcDefinitions);
session.TraitTriggerMap = traitMap;