import { useState, useEffect } from "react";
import { fetchCards } from "../service/CardService";
import { CardList } from "./CardList";

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
      <CardList items={cards} />
    </div>
  );
}