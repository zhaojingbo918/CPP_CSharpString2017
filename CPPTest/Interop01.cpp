#include "header.h"
#include "CPPTest.h"
#include "combaseapi.h"
 
//只能翻转英文，不能翻转中文
extern "C" __declspec(dllexport) void  __stdcall ReverseAnsiString(char* rawString, char* reversedString)
{ 
	int strLength = (int)strlen(rawString);

	strcpy(reversedString, rawString);

	char tempChar;
	for (int i = 0; i < strLength / 2; i++)
	{
		tempChar = reversedString[i];
		reversedString[i] = reversedString[strLength - 1 - i];
		reversedString[strLength - 1 - i] = tempChar;
	}
}



