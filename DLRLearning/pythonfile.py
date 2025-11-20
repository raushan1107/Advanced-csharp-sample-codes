
def getname():
	return "Hello I am Raushan";

def fahrenheit_to_celsius(fahrenheit):
  """
  Converts a temperature from Fahrenheit to Celsius.

  Args:
    fahrenheit: The temperature in Fahrenheit (float or int).

  Returns:
    The temperature in Celsius (float).
  """
  celsius = (fahrenheit - 32) * 5 / 9
  return celsius