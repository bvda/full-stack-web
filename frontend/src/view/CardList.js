import { CardListItem } from "./CardListItem";

export function CardList({items}) {
    return (
      <ul>
        {items.map(c => (
          <li key={c.name}>
            <CardListItem card={c} />
          </li>
        ))}
      </ul>
    );
  }