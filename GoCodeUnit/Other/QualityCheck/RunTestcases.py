from ScriptCollection.TFCPS.Go.TFCPS_CodeUnitSpecific_Go import TFCPS_CodeUnitSpecific_Go_Functions,TFCPS_CodeUnitSpecific_Go_CLI


def run_testcases():
    tf:TFCPS_CodeUnitSpecific_Go_Functions=TFCPS_CodeUnitSpecific_Go_CLI.parse(__file__)
    tf.run_testcases()


if __name__ == "__main__":
    run_testcases()
