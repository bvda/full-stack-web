export async function fetchCards() {
  const response = await fetch(
    'http://localhost:4000/card'
  );
  const data = await response.json();
  return data;
}