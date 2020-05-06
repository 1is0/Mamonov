#include "pch.h"
#include <utility>
#include <limits.h>
#include "MathLibrary.h"

double __stdcall Sh(double x)
{
	const int size = 100;
	double temp;
	double res = 0;
	for (int i = 0; i < size; i++)
	{
		temp = 1;
		for (int k = 0; k < 2 * i + 1; k++)
		{
			temp *= (x / (k + 1));
		}
		res += temp;
	}
	return res;
}

double __cdecl Ch(double x)
{
	const int size = 100;
	double temp;
	double res = 0;
	for (int i = 0; i < size; i++)
	{
		temp = 1;
		for (int k = 0; k < 2 * i; k++)
		{
			temp *= (x / (k + 1));
		}
		res += temp;
	}
	return res;
}
