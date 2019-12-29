<template>
    <div>
        <b-card style="max-width: 20rem;" class="mb-2 emailTile">
            <b-card-text>
                {{email.Subject}}
            </b-card-text>
        </b-card>
    </div>
</template>

<script>
    export default {
        name: 'EmailTile',
        props: {
            email: { type: Object }
        }
    };
</script>

<style scoped>
</style>