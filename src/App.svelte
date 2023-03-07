<script lang="ts">
	import ModeSwitcher from './ModeSwitcher.svelte';
	import Tailwindcss from './Tailwindcss.svelte';
	import QuoteList from './QuoteList.svelte';
	import NewQuote from './NewQuote.svelte';
</script>
<Tailwindcss />
<ModeSwitcher />
<main class="p-4 mx-auto text-center max-w-xl">
	<h1 class="uppercase text-6xl leading-normal font-thin text-svelte">Quoteboard</h1>
	<QuoteList />
	<NewQuote />
</main>