<template>
    <div>
       <div v-bind:key="SC.id" v-for="SC in slabComandas">
           <SlabComandaItem v-bind:SC="SC" v-on:del-slabComanda="$emit('del-slabComanda', SC.idSC)" />
       </div>
    </div>
</template>

<script>
import SlabComandaItem from './SlabComandaItem.vue'

export default {
    name: "SlabComanda",
    components: {
        SlabComandaItem
    },
    props: ["slabComandas"]
}
</script>

<style scoped>

</style>
