# ShopDomain

## Overview
ShopDomain is a Unity-based sample project that demonstrates a modular "bundle shop" domain architecture. It shows how to define domains (Gold, Health, VIP, Location), bind them to UI, and process purchases with price and reward actions through a modular Shop controller.

## Features
- Modular domain controllers and providers (Gold, Health, VIP, Location)
- ScriptableObject-driven bundle definitions and actions
- Modular `ShopController` for price checks and purchases
- UI views for shop list and bundle details
- Simple server request simulation via `ServerService`
- Scene navigation via `SceneLoaderService`

## Tech Stack
- Unity 2022.3.62f1
- C# 9.0
- .NET Framework 4.7.1 (per project configuration)

## Project Structure
- `Core`: Common abstractions and services
  - `Abstractions`: `DomainController`, `DomainProvider`, `BundleAction`, `BundleActionSO`, `ValueKey`, interfaces
  - `PlayerData`: Simple in-memory player data store
  - `Services`: `SceneLoaderService`, `ServerService`
- `Domains`
  - `Gold`: `GoldController`, actions, UI provider, key
  - `Health`: `HealthController`, actions, UI provider, key
  - `VIP`: `VIPController`, actions, UI provider, key
  - `Location`: `LocationController`, actions, UI provider, key
- `Shop`
  - `Controllers`: `ShopController`
  - `Models`: `BundleSO`
  - `Services`: `ShopService`, `ShopDetailService`, `BundleNavigation`
  - `Views`: `BundleShopView`, `BundleShopDetailView`, `BundleCardView`

## Core Concepts
- Bundle
  - Defined by `BundleSO` with `CostActions` and `RewardActions`
  - Cost actions reduce player resources; reward actions grant items or change state
- Domain Controllers
  - Implement price and reward application logic
  - Decide if an action can apply via `CanApply(BundleAction)`
- Providers
  - `DomainProvider` wires keys, controllers, and UI providers at runtime


## Usage
- Start the main shop scene.
- The shop lists configured bundles.
- Press `Buy` to simulate a server call and process purchase if allowed.
- Press `Info` to navigate to the bundle detail scene.

