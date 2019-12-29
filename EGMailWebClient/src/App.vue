<template>
    <div id="app">
        <Home msg="Hello world!" />
        <EmailTileList />
    </div>
    
</template>

<script>
    import Home from './components/Home.vue';
    import EmailTileList from './components/EmailTileList.vue';
    

    export default {
        name: 'app',
        components: {
            Home,
            EmailTileList
        }
    };
</script>

<style>
</style>
