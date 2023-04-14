export async function fetchSets() {
  const response = await fetch(
    'http://localhost:4000/set'
  );
  const data = await response.json();
  return data;
}