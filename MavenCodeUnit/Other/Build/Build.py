from ScriptCollection.TFCPS.Maven.TFCPS_CodeUnitSpecific_Maven import TFCPS_CodeUnitSpecific_Maven_Functions,TFCPS_CodeUnitSpecific_Maven_CLI


def build():
    tf:TFCPS_CodeUnitSpecific_Maven_Functions=TFCPS_CodeUnitSpecific_Maven_CLI.parse(__file__)
    tf.build()


if __name__ == "__main__":
    build()
