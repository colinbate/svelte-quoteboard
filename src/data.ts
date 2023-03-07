import { writable } from "svelte/store";
import type { Quote } from "./types";

const BASE_URI = '/';

export const quotes = writable<Quote[]>([]);

export function formatDate(date: string) {
  return date.replace(/T.*$/, '');
}

export async function loadQuotes() {
  const url = BASE_URI + 'quotes';
  const res = await fetch(url);
  const data: Quote[] = await res.json();
  quotes.set(data);
}

export async function addQuote(quote: Partial<Quote>) {
  const url = BASE_URI + 'quotes';
  if (!quote.date) {
    quote.date = (new Date()).toISOString();
  }
  const opts: RequestInit = {
    body: JSON.stringify(quote),
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
  };
  const res = await fetch(url, opts);
  const data: Quote = await res.json();
  quotes.update(qs => [...qs, data]);
}
