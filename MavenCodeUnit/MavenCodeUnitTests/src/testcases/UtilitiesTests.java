package testcases;

import static org.junit.Assert.assertEquals;
import org.junit.Test;

public class UtilitiesTests {
 
	@Test
	public void test() {
		assertEquals("Hello World",new miscellaneous.Utilities().getMessage());
	}

}
