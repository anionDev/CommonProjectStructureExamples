from ScriptCollection.TFCPS.CPP.TFCPS_CodeUnitSpecific_CPP import TFCPS_CodeUnitSpecific_CPP_Functions, TFCPS_CodeUnitSpecific_CPP_CLI


def build():
    """Compiles the c-executable and provides it as build-artifact.

    CExecutable is only built for linux, and always inside a docker-container (see linux_use_docker), so the
    build is reproducible independent of the host-operating-system it runs on. It links against the
    build-artifact of the dependent codeunit CPPLibrary, which CommonTasks.py placed at
    Other/Resources/DependentCodeUnits/CPPLibrary/BuildResult_Linux (see src/Makefile)."""
    tf: TFCPS_CodeUnitSpecific_CPP_Functions = TFCPS_CodeUnitSpecific_CPP_CLI.parse(__file__)
    tf.linux_docker_image = "Debian"  # defined in .ScriptCollection/OCIImages/ImageDefinition.csv
    tf.linux_docker_setup_commands = ["apt-get update", "apt-get install -y --no-install-recommends g++ make"]
    tf.linux_build_commands = ["make"]
    tf.linux_output_file_patterns = ["build/cexecutable"]
    tf.build(["linux"])


if __name__ == "__main__":
    build()
