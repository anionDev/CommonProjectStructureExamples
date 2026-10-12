CC ?= gcc
CFLAGS ?= -Wall -Wextra -O2
# CPPLibrary's build-artifact (its static library and header) as placed by CommonTasks.py (see
# TFCPS_Tools_General.copy_artifacts_from_dependent_code_units).
CPPLIBRARY_DIR ?= ../Other/Resources/DependentCodeUnits/CPPLibrary/BuildResult_Linux

build/cexecutable: main.c
	mkdir -p build
	$(CC) $(CFLAGS) -I$(CPPLIBRARY_DIR) main.c -L$(CPPLIBRARY_DIR) -lcpplibrary -lstdc++ -o $@

.PHONY: clean
clean:
	rm -rf build
