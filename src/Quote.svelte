<script lang="ts">
  import type { Quote } from "./types";
  import { formatDate } from './data';
  export let quote: Quote;
</script>
<div class="text-right">
  <div class="relative rounded-md text-left border border-gray-300 bg-white dark:border-gray-900 dark:bg-gray-700 px-6 py-5 shadow-sm flex items-center space-x-3 focus-within:ring-2 focus-within:ring-offset-2">
    <div class="text-sm font-medium">{quote.text}</div>
  </div>
  <div class="inline-block relative max-w-[calc(100%-2.5rem)] before:absolute before:w-0 before:h-0 before:left-[calc(-2rem-1px)] before:-top-px before:border-[calc(0.75rem+1px)] before:border-t-gray-300 before:border-r-gray-300 dark:before:border-t-gray-900 dark:before:border-r-gray-900 before:border-b-transparent before:border-l-transparent after:absolute after:w-0 after:h-0 after:-left-8 after:-top-px after:border-[0.75rem] after:border-t-white after:border-r-white dark:after:border-t-gray-700 dark:after:border-r-gray-700 after:border-b-transparent after:border-l-transparent">
    <span class="text-sm">{quote.author}</span>
    <span class="text-sm ml-2 text-gray-500 dark:text-gray-400 whitespace-nowrap">{formatDate(quote.date)}</span>
  </div>
</div>
