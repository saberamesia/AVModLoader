# Axiom Verge Mod Loader

_Note: This README is a work in progress. I'm prioritizing releasing the project, and will work on the README incrementally._

## About

AVML is a mod loader library that can be patched into Axiom Verge. It provides a way for modules to define themselves by overriding the `Mod` class,
as well as providing hooks to insert new behavior into the game. The library is intended to be used with [AVModTools](https://github.com/saberamesia/AVModTools),
which will patch the library code into Axiom Verge, as well as installing hook invocations in the Axiom Verge code.

## Dependencies

This project requires references to the Axiom Verge game executable and to FNA to build.

## Instructions (Windows)

Place `AVModLoader.DLL` and any mod DLLs in your Axiom Verge directory. Run `AVModTools` to patch the mod loader into the game.

## Future Plans

- Overriding existing game behavior
- No-code mods (for music, visual assets, etc.)
- A modding API for common or painful tasks like making menus