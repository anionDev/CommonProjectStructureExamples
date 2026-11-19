package de.aniondev.springapi.services;

import java.math.BigDecimal;
import java.math.MathContext;
import org.springframework.stereotype.Service;

/** The default implementation of {@link MathService}. */
@Service
public class DefaultMathService implements MathService {

  @Override
  public BigDecimal add(final BigDecimal value1, final BigDecimal value2) {
    return value1.add(value2);
  }

  @Override
  public BigDecimal sub(final BigDecimal value1, final BigDecimal value2) {
    return value1.subtract(value2);
  }

  @Override
  public BigDecimal mul(final BigDecimal value1, final BigDecimal value2) {
    return value1.multiply(value2);
  }

  @Override
  public BigDecimal div(final BigDecimal value1, final BigDecimal value2) {
    // A quotient like 1/3 has no finite decimal-representation, so the precision of the result is limited.
    return value1.divide(value2, MathContext.DECIMAL128);
  }
}
