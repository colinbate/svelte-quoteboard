<script lang="ts">
  import Quote from "./Quote.svelte";
  import { quotes, loadQuotes } from './data';
  import { onMount } from "svelte";

  onMount(() => {
    loadQuotes();
  })
</script>
<div class="grid grid-cols-1 gap-4 sm:grid-cols-2">
  {#each $quotes as quote (quote.id)}
    <Quote {quote} />
  {/each}
</div>