namespace cwic3.Exceptions;

public class ProductTypeMismatchException(Product expected, Product actual)
    : Exception("Expected: " + expected.Name + ", Received: " + actual.Name);