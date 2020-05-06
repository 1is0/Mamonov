#pragma once

#ifdef MATHLIBRARY_EXPORTS
#define MATHLIBRARY_API extern "C" __declspec(dllexport)
#else
#define MATHLIBRARY_API extern "C" __declspec(dllimport)
#endif

MATHLIBRARY_API double __stdcall Sh(double x);

MATHLIBRARY_API double __cdecl Ch(double x);
