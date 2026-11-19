package de.aniondev.springapi.services;

import java.math.BigDecimal;

/** Provides basic arithmetic functions. */
public interface MathService {

  /**
   * Adds two values.
   *
   * @param value1 summand 1
   * @param value2 summand 2
   * @return the sum of the given values
   */
  BigDecimal add(BigDecimal value1, BigDecimal value2);

  /**
   * Subtracts two values.
   *
   * @param value1 minuend
   * @param value2 subtrahend
   * @return the difference of the given values
   */
  BigDecimal sub(BigDecimal value1, BigDecimal value2);

  /**
   * Multiplies two values.
   *
   * @param value1 factor 1
   * @param value2 factor 2
   * @return the product of the given values
   */
  BigDecimal mul(BigDecimal value1, BigDecimal value2);

  /**
   * Divides two values.
   *
   * @param value1 dividend
   * @param value2 divisor
   * @return the quotient of the given values
   * @throws ArithmeticException if the divisor is zero
   */
  BigDecimal div(BigDecimal value1, BigDecimal value2);
}
