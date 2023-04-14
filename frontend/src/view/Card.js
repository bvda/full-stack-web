import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { fetchCard } from "../service/CardService";

export function CardView() {
  const { id } = useParams();
  const [card, setCard] = useState([]);

  useEffect(() => {
    const getCard = async () => {
      try {
        const data = await fetchCard(id);
        setCard(data);
      } catch (error) {
        console.error(error);
      }
    };

    getCard();
  }, [id]);

  return (
    <div>
      <h1>Cards</h1>
      <ul>
        {JSON.stringify(card)}
      </ul>
    </div>
  );
}