from ScriptCollection.TFCPS.Go.TFCPS_CodeUnitSpecific_Go import TFCPS_CodeUnitSpecific_Go_Functions,TFCPS_CodeUnitSpecific_Go_CLI


def build():
    tf:TFCPS_CodeUnitSpecific_Go_Functions=TFCPS_CodeUnitSpecific_Go_CLI.parse(__file__)
    tf.build()


if __name__ == "__main__":
    build()
