from ScriptCollection.TFCPS.Maven.TFCPS_CodeUnitSpecific_Maven import TFCPS_CodeUnitSpecific_Maven_Functions,TFCPS_CodeUnitSpecific_Maven_CLI


def run_testcases():
    tf:TFCPS_CodeUnitSpecific_Maven_Functions=TFCPS_CodeUnitSpecific_Maven_CLI.parse(__file__)
    tf.run_testcases()


if __name__ == "__main__":
    run_testcases()
