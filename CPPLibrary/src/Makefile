CXX ?= g++
CXXFLAGS ?= -std=c++17 -Wall -Wextra -O2 -fPIC
AR ?= ar

build/libcpplibrary.a: build/cpplibrary.o
	$(AR) rcs $@ $^

build/cpplibrary.o: cpplibrary.cpp include/cpplibrary.h
	mkdir -p build
	$(CXX) $(CXXFLAGS) -Iinclude -c cpplibrary.cpp -o $@

.PHONY: clean
clean:
	rm -rf build
