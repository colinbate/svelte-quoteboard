<script lang="ts">
  import { addQuote } from './data';
  import { fly } from 'svelte/transition';

  let open = false;
  let text = '';
  let author = '';
  let date = '';

  function handleSubmit() {
    if (!text || !author) {
      return;
    }

    addQuote({ text, author, date });
    text = '';
    author = '';
    date = '';
    open = false;
  }
</script>
{#if open}
<form on:submit|preventDefault={handleSubmit} transition:fly={{duration: 400, y: 200}} class="bg-gray-200 dark:bg-gray-900 z-10 border-t border-t-gray-300 dark:border-t-gray-700 rounded-t-xl w-screen fixed bottom-0 right-0 sm:w-[640px] p-4">
  <div class="my-4 grid grid-cols-1 gap-y-3 gap-x-4 sm:grid-cols-6">

    <div class="sm:col-span-6">
      <label for="text" class="sr-only">Quote</label>
      <div class="mt-1">
        <textarea placeholder="Quote" bind:value={text} id="text" name="text" rows="3" class="p-2 shadow-sm focus:ring-svelte focus:border-svelte rin outline-none block w-full border bg-gray-50 border-gray-300 dark:border-gray-900 dark:bg-gray-700 rounded-md"></textarea>
      </div>
    </div>

    <div class="sm:col-span-4 sm:col-start-3">
      <label for="author" class="sr-only">Author</label>
      <div class="mt-1">
        <input placeholder="Author" bind:value={author} id="author" name="author" type="text" class="p-2 shadow-sm focus:ring-svelte focus:border-svelte outline-none block w-full border bg-gray-50 border-gray-300 dark:border-gray-900 dark:bg-gray-700 rounded-md">
      </div>
    </div>

    <div class="sm:col-span-4 sm:col-start-3">
      <label for="date" class="sr-only">Date (optional)</label>
      <div class="mt-1">
        <input placeholder="Date (optional)" bind:value={date} id="date" name="date" type="date" class="p-2 shadow-sm focus:ring-svelte focus:border-svelte outline-none block w-full border bg-gray-50 border-gray-300 dark:border-gray-900 dark:bg-gray-700 rounded-md">
      </div>
    </div>

    <div class="sm:col-span-6 text-right">
      <button type="submit" class="bg-svelte border-svelte border-2 text-white rounded-md shadow-sm px-6 py-2">Add</button>
      <button type="button" class="border-svelte border-2 rounded-md shadow-sm px-6 py-2" on:click={() => open = false}>Close</button>
    </div>
  </div>
</form>
{/if}
<button type="button" on:click={() => open = true} class="bg-svelte fixed bottom-4 right-4 shadow-md rounded-full text-2xl flex items-center justify-center h-12 w-12 p-3 text-white"><svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"><path fill="currentColor" d="M432 256c0 17.69-14.33 32.01-32 32.01H256v144c0 17.69-14.33 31.99-32 31.99s-32-14.3-32-31.99v-144H48c-17.67 0-32-14.32-32-32.01s14.33-31.99 32-31.99H192v-144c0-17.69 14.33-32.01 32-32.01s32 14.32 32 32.01v144h144C417.7 224 432 238.3 432 256z"/></svg></button>