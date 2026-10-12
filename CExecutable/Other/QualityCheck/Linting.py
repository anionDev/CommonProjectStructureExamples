from ScriptCollection.TFCPS.CPP.TFCPS_CodeUnitSpecific_CPP import TFCPS_CodeUnitSpecific_CPP_Functions, TFCPS_CodeUnitSpecific_CPP_CLI


def linting():
    tf: TFCPS_CodeUnitSpecific_CPP_Functions = TFCPS_CodeUnitSpecific_CPP_CLI.parse(__file__)
    tf.linting()


if __name__ == "__main__":
    linting()
