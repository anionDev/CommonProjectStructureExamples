from ScriptCollection.TFCPS.CPP.TFCPS_CodeUnitSpecific_CPP import TFCPS_CodeUnitSpecific_CPP_Functions, TFCPS_CodeUnitSpecific_CPP_CLI


def build():
    """Compiles the c++-library and provides it (the static library and its header) as build-artifact.

    CPPLibrary is only built for linux, and always inside a docker-container (see linux_use_docker), so the
    build is reproducible independent of the host-operating-system it runs on."""
    tf: TFCPS_CodeUnitSpecific_CPP_Functions = TFCPS_CodeUnitSpecific_CPP_CLI.parse(__file__)
    tf.linux_docker_image = "Debian"  # defined in .ScriptCollection/OCIImages/ImageDefinition.csv
    tf.linux_docker_setup_commands = ["apt-get update", "apt-get install -y --no-install-recommends g++ make"]
    tf.linux_build_commands = ["make"]
    # The header is published together with the compiled library, because a codeunit which depends on this one
    # (see CExecutable) needs it to be able to compile against CPPLibrary's api.
    tf.linux_output_file_patterns = ["build/libcpplibrary.a", "include/cpplibrary.h"]
    tf.build(["linux"])


if __name__ == "__main__":
    build()
