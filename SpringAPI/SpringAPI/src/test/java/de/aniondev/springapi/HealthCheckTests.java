package de.aniondev.springapi;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.jsonPath;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.webmvc.test.autoconfigure.AutoConfigureMockMvc;
import org.springframework.test.web.servlet.MockMvc;

/** Contains the testcases for the health-check-endpoint which is configured for this codeunit. */
@SpringBootTest
@AutoConfigureMockMvc
final class HealthCheckTests {

  @Autowired private MockMvc mockMvc;

  @Test
  void healthCheckShouldReportThatTheApplicationIsUp() throws Exception {
    mockMvc
        .perform(get("/HealthCheck"))
        .andExpect(status().isOk())
        .andExpect(jsonPath("$.status").value("UP"));
  }
}
