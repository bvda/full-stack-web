import { useState, useEffect } from "react";
import { fetchCards } from "../service/CardService";
export function CardsView() {
  const [cards, setCards] = useState([]);

  useEffect(() => {
    const getCards = async () => {
      try {
        const data = await fetchCards();
        setCards(data);
      } catch (error) {
        console.error(error);
      }
    };

    getCards();
  }, []);

  return (
    <div>
      <h1>Cards</h1>
      <ul>
        {cards.map((c) => (
          <li key={c.name}>{c.name}</li>
        ))}
      </ul>
    </div>
  );
}