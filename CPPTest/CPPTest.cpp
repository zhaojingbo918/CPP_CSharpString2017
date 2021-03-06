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
	char szSampleString[] = "Hello World ANSI String  中文";
	  int ulSize = strlen(szSampleString) + sizeof(char);
	char* pszReturn = NULL;

	pszReturn = (char*)::CoTaskMemAlloc(ulSize);
	// Copy the contents of szSampleString
	// to the memory pointed to by pszReturn.
	strcpy(pszReturn, szSampleString);
	// Return pszReturn.
	return pszReturn;
}


//using BSTR
extern "C" __declspec(dllexport) BSTR  __stdcall StringReturnAPI02()
{
	return ::SysAllocString((const OLECHAR*)L"Hello World BSTR String 中文");
}


//using Unicode strings 
extern "C" __declspec(dllexport) wchar_t*  __stdcall StringReturnAPI03()
{
	// Declare a sample wide character string.
	wchar_t  wszSampleString[] = L"Hello World  Unicode strings 中文 ";
	ULONG  ulSize = (wcslen(wszSampleString) * sizeof(wchar_t)) + sizeof(wchar_t);
	wchar_t* pwszReturn = NULL;

	pwszReturn = (wchar_t*)::CoTaskMemAlloc(ulSize);
	// Copy the contents of wszSampleString
	// to the memory pointed to by pwszReturn.
	wcscpy(pwszReturn, wszSampleString);
	// Return pwszReturn.
	return pwszReturn;
}

// Low-Level handling Sample 1
extern "C" __declspec(dllexport) char*  __stdcall PtrReturnAPI01()
{
	char   szSampleString[] = "Hello World Low-Level handling Sample 1";
	ULONG  ulSize = strlen(szSampleString) + sizeof(char);
	char*  pszReturn = NULL;

	pszReturn = (char*)::GlobalAlloc(GMEM_FIXED, ulSize);
	// Copy the contents of szSampleString
	// to the memory pointed to by pszReturn.
	strcpy(pszReturn, szSampleString);
	// Return pszReturn.
	return pszReturn;
}

// Low-Level Handling Sample 2
wchar_t gwszSampleString[] = L"Global Hello World";

extern "C" __declspec(dllexport) wchar_t*  __stdcall PtrReturnAPI02()
{
	return gwszSampleString;
}
 