#include "cpplibrary.h"

#include <string>

namespace
{
    const std::string example_message = "Hello from CPPLibrary, a c++-library built by TFCPS_CodeUnitSpecific_CPP!";
}

extern "C" const char *cpplibrary_get_example_message(void)
{
    return example_message.c_str();
}
