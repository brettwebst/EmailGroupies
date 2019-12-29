<template>
    <div class="EmailTileList">
        <EmailTile v-for="item in emails" v-bind:email="item" v-bind:key="item.id"></EmailTile>
        <b-button @click="addEmails">Get Emails</b-button>
    </div>
</template>

<script>
    import EmailTile from './EmailTile.vue';


    export default {
        name: 'EmailTileList',
        components: {
            EmailTile
        },
        data: function () {
            return {
                emails: []
            };
        },
        methods: {
            addEmails: function () {
                this.emails.push({ "id": this.emails.length + 1, "Subject": getSubject(this.emails.length) });
            }
        }
    };

    function getSubject(id) {
        var defaultEmails = [
            "tacos", "burritos", "enchiladas"
        ];

        if (id < defaultEmails.length) { return defaultEmails[id]; }
        return "Dynamically Added";
    }
</script>

<style scoped>
</style>