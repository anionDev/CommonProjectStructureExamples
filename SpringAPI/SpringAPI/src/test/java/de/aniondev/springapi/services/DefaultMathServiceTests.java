package de.aniondev.springapi.services;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

import java.math.BigDecimal;
import org.junit.jupiter.api.Test;

/** Contains the testcases for {@link DefaultMathService}. */
final class DefaultMathServiceTests {

  private final MathService mathService = new DefaultMathService();

  @Test
  void addShouldReturnTheSum() {
    assertEquals(new BigDecimal("5.5"), mathService.add(new BigDecimal("2"), new BigDecimal("3.5")));
  }

  @Test
  void subShouldReturnTheDifference() {
    assertEquals(new BigDecimal("-1.5"), mathService.sub(new BigDecimal("2"), new BigDecimal("3.5")));
  }

  @Test
  void mulShouldReturnTheProduct() {
    assertEquals(new BigDecimal("7.0"), mathService.mul(new BigDecimal("2"), new BigDecimal("3.5")));
  }

  @Test
  void divShouldReturnTheQuotient() {
    assertEquals(new BigDecimal("2.5"), mathService.div(new BigDecimal("5"), new BigDecimal("2")));
  }

  @Test
  void divShouldReturnARoundedQuotientWhenTheQuotientHasNoFiniteRepresentation() {
    assertEquals(
        new BigDecimal("0.3333333333333333333333333333333333"),
        mathService.div(BigDecimal.ONE, new BigDecimal("3")));
  }

  @Test
  void divShouldThrowWhenTheDivisorIsZero() {
    assertThrows(ArithmeticException.class, () -> mathService.div(BigDecimal.ONE, BigDecimal.ZERO));
  }
}
