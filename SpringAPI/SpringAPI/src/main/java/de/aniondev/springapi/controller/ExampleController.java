package de.aniondev.springapi.controller;

import de.aniondev.springapi.services.MathService;
import java.math.BigDecimal;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

/** Represents an example-controller. */
@RestController
@RequestMapping(ExampleController.CONTROLLER_ROUTE)
public class ExampleController {

  /** The route of this controller. It contains the major-version of this codeunit. */
  public static final String CONTROLLER_ROUTE = "/API/v${springapi.majorversion}/ExampleController";

  private final MathService mathService;

  /**
   * Creates the controller.
   *
   * @param mathService the service which does the calculations
   */
  public ExampleController(final MathService mathService) {
    this.mathService = mathService;
  }

  /**
   * Applies the given arithmetic function to two values.
   *
   * <p>Example-route: /API/v1/ExampleController/Calculator/Add?parameter1=2&amp;parameter2=3.5
   *
   * @param function the name of the function: "Add", "Sub", "Mul" or "Div"
   * @param parameter1 the first operand. Decimal-places must be separated by a dot.
   * @param parameter2 the second operand. Decimal-places must be separated by a dot.
   * @return the result of the calculation, or statuscode 400 if the function is unknown
   */
  @GetMapping("Calculator/{function}")
  public ResponseEntity<Object> calculate(
      @PathVariable final String function,
      @RequestParam final BigDecimal parameter1,
      @RequestParam final BigDecimal parameter2) {
    return switch (function) {
      case "Add" -> ResponseEntity.ok(mathService.add(parameter1, parameter2));
      case "Sub" -> ResponseEntity.ok(mathService.sub(parameter1, parameter2));
      case "Mul" -> ResponseEntity.ok(mathService.mul(parameter1, parameter2));
      case "Div" -> ResponseEntity.ok(mathService.div(parameter1, parameter2));
      default -> ResponseEntity.badRequest().body("Unknown function: \"" + function + "\"");
    };
  }

  /**
   * Answers a calculation which is not defined (for example a division by zero) with statuscode
   * 400, because the cause is the input of the caller and not a failure of the server.
   *
   * @param exception the exception which was thrown by the calculation
   * @return the response with statuscode 400
   */
  @ExceptionHandler(ArithmeticException.class)
  public ResponseEntity<Object> handleArithmeticException(final ArithmeticException exception) {
    return ResponseEntity.badRequest().body(exception.getMessage());
  }
}
