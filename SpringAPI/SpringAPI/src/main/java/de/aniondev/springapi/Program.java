package de.aniondev.springapi;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

/** Contains the entry-point of this codeunit. */
@SpringBootApplication
public class Program {

  /**
   * The entry-point of this codeunit. It starts the web-server which provides the API.
   *
   * @param args the commandline-arguments
   */
  public static void main(final String[] args) {
    SpringApplication.run(Program.class, args);
  }
}
