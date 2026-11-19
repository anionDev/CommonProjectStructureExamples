from ScriptCollection.TFCPS.Maven.TFCPS_CodeUnitSpecific_Maven import TFCPS_CodeUnitSpecific_Maven_Functions,TFCPS_CodeUnitSpecific_Maven_CLI


def update_dependencies():
    tf:TFCPS_CodeUnitSpecific_Maven_Functions=TFCPS_CodeUnitSpecific_Maven_CLI.parse(__file__)
    tf.update_dependencies()


if __name__ == "__main__":
    update_dependencies()
