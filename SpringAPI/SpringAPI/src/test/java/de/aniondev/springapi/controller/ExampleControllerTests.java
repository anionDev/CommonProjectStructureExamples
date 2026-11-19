package de.aniondev.springapi.controller;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.webmvc.test.autoconfigure.AutoConfigureMockMvc;
import org.springframework.test.web.servlet.MockMvc;

/**
 * Contains the testcases for {@link ExampleController}. They start the whole application, so that
 * the configuration (for example the route which contains the major-version) is tested as well.
 */
@SpringBootTest
@AutoConfigureMockMvc
final class ExampleControllerTests {

  @Autowired private MockMvc mockMvc;

  @Value("${springapi.majorversion}")
  private String majorVersion;

  @Test
  void calculateShouldReturnTheSum() throws Exception {
    mockMvc
        .perform(
            get(getCalculatorRoute() + "Add").param("parameter1", "2").param("parameter2", "3.5"))
        .andExpect(status().isOk())
        .andExpect(content().string("5.5"));
  }

  @Test
  void calculateShouldReturnTheDifference() throws Exception {
    mockMvc
        .perform(
            get(getCalculatorRoute() + "Sub").param("parameter1", "2").param("parameter2", "3.5"))
        .andExpect(status().isOk())
        .andExpect(content().string("-1.5"));
  }

  @Test
  void calculateShouldReturnTheProduct() throws Exception {
    mockMvc
        .perform(
            get(getCalculatorRoute() + "Mul").param("parameter1", "2").param("parameter2", "3.5"))
        .andExpect(status().isOk())
        .andExpect(content().string("7.0"));
  }

  @Test
  void calculateShouldReturnTheQuotient() throws Exception {
    mockMvc
        .perform(get(getCalculatorRoute() + "Div").param("parameter1", "5").param("parameter2", "2"))
        .andExpect(status().isOk())
        .andExpect(content().string("2.5"));
  }

  @Test
  void calculateShouldReturnBadRequestForAnUnknownFunction() throws Exception {
    mockMvc
        .perform(get(getCalculatorRoute() + "Pow").param("parameter1", "2").param("parameter2", "3"))
        .andExpect(status().isBadRequest());
  }

  @Test
  void calculateShouldReturnBadRequestForADivisionByZero() throws Exception {
    mockMvc
        .perform(get(getCalculatorRoute() + "Div").param("parameter1", "1").param("parameter2", "0"))
        .andExpect(status().isBadRequest());
  }

  private String getCalculatorRoute() {
    return "/API/v" + majorVersion + "/ExampleController/Calculator/";
  }
}
