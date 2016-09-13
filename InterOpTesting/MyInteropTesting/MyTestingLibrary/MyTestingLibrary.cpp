// MyTestingLibrary.cpp : Defines the exported functions for the DLL application.
//
#include <iostream>
#include <string>
#include <stdio.h>
#include <time.h>
#include "stdafx.h"


extern "C"
{
	__declspec(dllexport) int __stdcall GetResult(int arg)
	{
		return arg;
	}
}