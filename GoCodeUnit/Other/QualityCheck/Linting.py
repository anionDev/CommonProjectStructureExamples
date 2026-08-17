from ScriptCollection.TFCPS.Go.TFCPS_CodeUnitSpecific_Go import TFCPS_CodeUnitSpecific_Go_Functions,TFCPS_CodeUnitSpecific_Go_CLI


def linting():
    tf:TFCPS_CodeUnitSpecific_Go_Functions=TFCPS_CodeUnitSpecific_Go_CLI.parse(__file__)
    tf.linting()


if __name__ == "__main__":
    linting()
