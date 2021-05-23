// CPPTest.cpp : 定义 DLL 应用程序的导出函数。
//

#include "header.h"
#include "CPPTest.h"
#include "combaseapi.h"


// 这是导出变量的一个示例
CPPTEST_API int nCPPTest=0;

// 这是导出函数的一个示例。
CPPTEST_API int fnCPPTest(void)
{
    return 42;
}

// 这是已导出类的构造函数。
CCPPTest::CCPPTest()
{
    return;
}


extern "C"  CPPTEST_API int fnCPPTest2(void)
{
	return 42;
}


extern "C" __declspec(dllexport) char*  __stdcall StringReturnAPI01()
{
	char szSampleString[] = "Hello World ANSI String";
	  int ulSize = strlen(szSampleString) + sizeof(char);
	char* pszReturn = NULL;

	pszReturn = (char*)::CoTaskMemAlloc(ulSize);
	// Copy the contents of szSampleString
	// to the memory pointed to by pszReturn.
	strcpy(pszReturn, szSampleString);
	// Return pszReturn.
	return pszReturn;
}